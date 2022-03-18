function solve(worker) {
    if (worker.dizziness) {
        worker.levelOfHydrated += Number(worker.weight) * Number(worker.experience) * Number(0.1);
    }

    return worker;
}

console.log(solve({
    weight: 120,
    experience: 20,
    levelOfHydrated: 200,
    dizziness: false
}));
